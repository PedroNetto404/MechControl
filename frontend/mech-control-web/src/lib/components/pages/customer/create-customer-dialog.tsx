import React, { useMemo, useState } from "react";
import {
  Dialog,
  DialogTitle,
  DialogContent,
  DialogActions,
  Button,
  IconButton,
  Stack,
  Typography,
  Alert,
  List,
} from "@mui/material";
import { Close as CloseIcon } from "@mui/icons-material";
import CreateCustomerStepper from "./create-customer-stepper";
import { Customer } from "@/types/customer";
import { Vehicle } from "@/types/vehicle";
import { CarSystem } from "@/types/enums/car-system";
import { FuelType } from "@/types/enums/fuel-type";
import { TransmissionType } from "@/types/enums/transmission-type";
import { CustomerType } from "@/types/enums/customer-type";
import { HttpResource } from "@/services/http-resource";

type FormData = Customer & { vehicle: Vehicle };

type CreateCustomerDialogProps = {
  open: boolean;
  handleClose: () => void;
};

const CreateCustomerDialog = ({
  open,
  handleClose,
}: CreateCustomerDialogProps) => {
  const [activeStep, setActiveStep] = useState(0);
  const [formData, setFormData] = useState<FormData>({
    id: "",
    name: "",
    email: "",
    phone: "",
    addressStreet: "",
    addressNumber: "",
    addressNeighborhood: "",
    addressCity: "",
    addressCountryCode: "",
    addressStateCode: "",
    addressZipCode: "",
    document: "",
    mechShopId: "",
    createdOnUtc: new Date(),
    modifiedOnUtc: new Date(),
    type: CustomerType.individual,
    vehicle: {
      plate: "",
      color: "",
      model: "",
      brand: "",
      vin: "",
      manufactoryYear: 0,
      fuelType: FuelType.gasoline,
      currentMileage: 0,
      id: "",
      transmission: TransmissionType.manual,
      systemDetails: {
        [CarSystem.airConditioning]: "",
        [CarSystem.electrical]: "",
        [CarSystem.engine]: "",
        [CarSystem.transmission]: "",
        [CarSystem.suspension]: "",
        [CarSystem.braking]: "",
        [CarSystem.cooling]: "",
        [CarSystem.other]: "",
      },
    },
  });

  const handleFormDataChange = (newData: Partial<FormData>) => {
    setFormData((prevData) => ({
      ...prevData,
      ...newData,
    }));
  };

  const handleNext = () => {
    setActiveStep((prevActiveStep) => prevActiveStep + 1);
  };

  const handleBack = () => {
    setActiveStep((prevActiveStep) => prevActiveStep - 1);
  };

  const customerApiResource = useMemo(
    () => new HttpResource<Customer>("customers"),
    []
  );
  const vehicleApiResource = useMemo(
    () => new HttpResource<Vehicle>("vehicles"),
    []
  );

  const handleFinish = async () => {
    try {
      const customer = await customerApiResource.create(formData);
      if (!customer) return;
      await vehicleApiResource.create(formData.vehicle);
      handleClose();
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <Dialog
      open={open}
      onClose={handleClose}
      fullWidth
      maxWidth="md"
      sx={{
        "& .MuiDialog-paper": {
          minHeight: "80vh",
          minWidth: "80vw",
        },
      }}
    >
      <DialogTitle>
        <Stack direction="row" justifyContent="space-between">
          <Typography variant="h5">Cadastrar Cliente</Typography>
          <IconButton onClick={handleClose}>
            <CloseIcon />
          </IconButton>
        </Stack>
      </DialogTitle>
      <DialogContent>
        <CreateCustomerStepper
          activeStep={activeStep}
          handleFormDataChange={handleFormDataChange}
        />
      </DialogContent>
      <DialogActions>
        {activeStep !== 0 && <Button onClick={handleBack}>Voltar</Button>}
        {activeStep === 2 ? (
          <Button onClick={handleFinish} color="primary">
            Finalizar
          </Button>
        ) : (
          <Button onClick={handleNext} color="primary">
            Próximo
          </Button>
        )}
      </DialogActions>
    </Dialog>
  );
};

export default CreateCustomerDialog;
