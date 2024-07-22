import React from "react";
import { TextField, Grid, MenuItem } from "@mui/material";
import { FuelType } from "@/types/enums/fuel-type";
import { TransmissionType } from "@/types/enums/transmission-type";

type VehicleFormProps = {
  onChange: (data: any) => void;
};

const VehicleForm = ({ onChange }: VehicleFormProps): JSX.Element => {
  return (
    <Grid container spacing={2}>
      <Grid item xs={12} sm={6}>
        <TextField
          fullWidth
          label="Placa"
          name="plate"
          variant="outlined"
          onChange={onChange}
        />
      </Grid>
      <Grid item xs={12} sm={6}>
        <TextField
          fullWidth
          label="Cor"
          name="color"
          variant="outlined"
          onChange={onChange}
        />
      </Grid>
      <Grid item xs={12} sm={6}>
        <TextField
          fullWidth
          label="Modelo"
          name="model"
          variant="outlined"
          onChange={onChange}
        />
      </Grid>
      <Grid item xs={12} sm={6}>
        <TextField
          fullWidth
          label="Marca"
          name="brand"
          variant="outlined"
          onChange={onChange}
        />
      </Grid>
      <Grid item xs={12} sm={6}>
        <TextField
          fullWidth
          label="VIN"
          name="vin"
          variant="outlined"
          onChange={onChange}
        />
      </Grid>
      <Grid item xs={12} sm={6}>
        <TextField
          fullWidth
          label="Ano de Fabricação"
          name="manufactoryYear"
          type="number"
          variant="outlined"
          onChange={onChange}
        />
      </Grid>
      <Grid item xs={12} sm={6}>
        <TextField
          fullWidth
          label="Quilometragem Atual"
          name="currentMileage"
          type="number"
          variant="outlined"
          onChange={onChange}
        />
      </Grid>
      <Grid item xs={12} sm={6}>
        <TextField
          fullWidth
          select
          label="Tipo de Transmissão"
          name="transmission"
          variant="outlined"
          onChange={onChange}
        >
          <MenuItem value="manual">Manual</MenuItem>
          <MenuItem value="automatic">Automática</MenuItem>
        </TextField>
      </Grid>
      <Grid item xs={12} sm={6}>
        <TextField
          fullWidth
          select
          label="Tipo de Combustível"
          name="fuelType"
          variant="outlined"
          onChange={onChange}
        >
          <MenuItem value="gasoline">Gasolina</MenuItem>
          <MenuItem value="diesel">Diesel</MenuItem>
          <MenuItem value="ethanol">Etanol</MenuItem>
          <MenuItem value="flexfuel">FlexFuel</MenuItem>
          <MenuItem value="electric">Elétrico</MenuItem>
          <MenuItem value="hybrid">Híbrido</MenuItem>
          <MenuItem value="other">Outro</MenuItem>
        </TextField>
      </Grid>
    </Grid>
  );
};

export default VehicleForm;