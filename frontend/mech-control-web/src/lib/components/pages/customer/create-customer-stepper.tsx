import React from "react";
import { Stepper, Step, StepLabel, Typography, Box } from "@mui/material";
import BasicDetailsForm from "./forms/basic-details-form";
import AddressForm from "./forms/address-form";
import VehicleForm from "./forms/vehicle-form";

const steps = ["Dados Básicos", "Endereço", "Veículo"];

type CreateCustomerStepperProps = {
  activeStep: number;
  handleFormDataChange: (newData: any) => void;
};

const CreateCustomerStepper = ({
  activeStep,
  handleFormDataChange,
}: CreateCustomerStepperProps) => {
  const getStepContent = (step: number) => {
    switch (step) {
      case 0:
        return <BasicDetailsForm onChange={handleFormDataChange} />;
      case 1:
        return <AddressForm onChange={handleFormDataChange} />;
      case 2:
        return <VehicleForm onChange={handleFormDataChange} />;
      default:
        return <Typography>Passo desconhecido</Typography>;
    }
  };

  return (
    <Box>
      <Stepper activeStep={activeStep}>
        {steps.map((label, index) => (
          <Step key={index}>
            <StepLabel>{label}</StepLabel>
          </Step>
        ))}
      </Stepper>
      <Box mt={2}>{getStepContent(activeStep)}</Box>
    </Box>
  );
};

export default CreateCustomerStepper;
