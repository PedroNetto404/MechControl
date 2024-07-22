"use client";

import React, { useState } from "react";
import IMask from "imask";
import {
  TextField,
  Grid,
  FormControlLabel,
  RadioGroup,
  Radio,
  Box,
  Stack,
  Container,
} from "@mui/material";

type BasicDetailsFormProps = {
  onChange: (data: any) => void;
};

const BasicDetailsForm = ({ onChange }: BasicDetailsFormProps): JSX.Element => {
  const [individualCustomerSelected, setIndividualCustomerSelected] =
    useState<boolean>(true);
  const [corporateCustomerSelected, setCorporateCustomerSelected] =
    useState<boolean>(false);

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    onChange({ [name]: value });
  };

  const applyMask = (element: HTMLInputElement, mask: string) => {
    IMask(element, { mask });
  };

  return (
    <Grid container spacing={2}>
      <Grid item xs={12} sm={6}>
        <TextField
          fullWidth
          label="Email"
          name="email"
          variant="outlined"
          onChange={handleChange}
        />
      </Grid>
      <Grid item xs={12} sm={6}>
        <TextField
          fullWidth
          label="Telefone"
          name="phone"
          variant="outlined"
          inputProps={{
            ref: (input: HTMLInputElement) =>
              input && applyMask(input, "(00) 00000-0000"),
          }}
          onChange={handleChange}
        />
      </Grid>

      <Container
        sx={{
          width: "100%",
          display: "flex",
          justifyContent: "start",
          margin: 0,
          py: 2,
        }}
      >
        <RadioGroup
          row
          aria-label="customerType"
          name="customerType"
          value={individualCustomerSelected ? "individual" : "corporate"}
          onChange={handleChange}
        >
          <FormControlLabel
            checked={individualCustomerSelected}
            value="individual"
            control={<Radio />}
            onChange={() => {
              setIndividualCustomerSelected(true);
              setCorporateCustomerSelected(false);
            }}
            label="Pessoa Física"
          />
          <FormControlLabel
            checked={corporateCustomerSelected}
            value="corporate"
            control={<Radio />}
            label="Pessoa Jurídica"
            onChange={() => {
              setIndividualCustomerSelected(false);
              setCorporateCustomerSelected(true);
            }}
          />
        </RadioGroup>
      </Container>
      {individualCustomerSelected && (
        <>
          <Grid item xs={12} sm={6}>
            <TextField
              fullWidth
              label="Nome Completo"
              name="fullname"
              variant="outlined"
              onChange={handleChange}
            />
          </Grid>
          <Grid item xs={12} sm={6}>
            <TextField
              fullWidth
              label="Data de Nascimento"
              name="birthDate"
              type="date"
              variant="outlined"
              InputLabelProps={{ shrink: true }}
              onChange={handleChange}
            />
          </Grid>
          <Grid item xs={12} sm={6}>
            <TextField
              fullWidth
              label="CPF"
              name="document"
              variant="outlined"
              inputProps={{
                ref: (input: HTMLInputElement) =>
                  input && applyMask(input, "000.000.000-00"),
              }}
              onChange={handleChange}
            />
          </Grid>
        </>
      )}

      {corporateCustomerSelected && (
        <>
          <Grid item xs={12} sm={6}>
            <TextField
              fullWidth
              label="Razão Social"
              name="corporateName"
              variant="outlined"
              onChange={handleChange}
            />
          </Grid>
          <Grid item xs={12} sm={6}>
            <TextField
              fullWidth
              label="CNPJ"
              name="document"
              variant="outlined"
              inputProps={{
                ref: (input: HTMLInputElement) =>
                  input && applyMask(input, "00.000.000/0000-00"),
              }}
              onChange={handleChange}
            />
          </Grid>

          <Grid item xs={12} sm={6}>
            <Box>
              <Stack direction="row" alignItems="center">
                <FormControlLabel
                  control={<Radio onChange={handleChange} />}
                  label="MEI"
                />
              </Stack>
            </Box>
          </Grid>
        </>
      )}
    </Grid>
  );
};

export default BasicDetailsForm;