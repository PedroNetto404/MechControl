"use client";

import React, { createRef, useEffect, useState } from "react";
import { TextField, Grid, CircularProgress, Box } from "@mui/material";
import axios from "axios";

type AddressFormProps = {
  onChange: (data: any) => void;
};

interface Address {
  street: string;
  number: string;
  neighborhood: string;
  complement: string;
  reference: string;
  city: string;
  stateCode: string;
  countryCode: string;
  zipCode: string;
}

const AddressForm = ({ onChange }: AddressFormProps): JSX.Element => {
  const streetNumberRef = createRef<HTMLInputElement>();
  const [loading, setLoading] = useState<boolean>(false);
  const [address, setAddress] = useState<Address>({
    street: "",
    number: "",
    neighborhood: "",
    complement: "",
    reference: "",
    city: "",
    stateCode: "",
    countryCode: "",
    zipCode: "",
  });

  const fetchAddress = async () => {
    const cleanZipCode = address.zipCode.replace(/\D/g, "");

    if (cleanZipCode.length !== 8) {
      setAddress({
        ...address,
        street: "",
        neighborhood: "",
        city: "",
        stateCode: "",
        countryCode: "",
      });
      return;
    }

    setLoading(true);

    try {
      const response = await axios.get(
        `https://viacep.com.br/ws/${cleanZipCode}/json/`
      );

      setAddress({
        ...address,
        street: response.data.logradouro,
        neighborhood: response.data.bairro,
        city: response.data.localidade,
        stateCode: response.data.uf,
        countryCode: "BR",
      });

      streetNumberRef.current?.focus();
    } catch (error) {
      console.error("Erro ao buscar endereço:", error);
      setAddress({
        ...address,
        street: "",
        neighborhood: "",
        city: "",
        stateCode: "",
        countryCode: "",
      });
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    if (address.zipCode) {
      fetchAddress();
    }
  }, [address.zipCode]);

  return (
    <Grid container spacing={2}>
      <Grid item xs={12} sm={6}>
        <TextField
          value={address.zipCode}
          fullWidth
          label="CEP"
          name="addressZipCode"
          variant="outlined"
          onChange={(e) => {
            setAddress({ ...address, zipCode: e.target.value });
            onChange({ ...address, zipCode: e.target.value });
          }}
        />
      </Grid>

      {loading && (
        <Grid item xs={12}>
          <Box display="flex" justifyContent="center" alignItems="center">
            <CircularProgress />
          </Box>
        </Grid>
      )}

      {!loading && address.street && (
        <>
          <Grid item xs={12} sm={6}>
            <TextField
              disabled
              fullWidth
              value={address.street}
              label="Rua"
              name="addressStreet"
              variant="outlined"
              onChange={onChange}
            />
          </Grid>
          <Grid item xs={12} sm={6}>
            <TextField
              ref={streetNumberRef}
              value={address.number}
              fullWidth
              label="Número"
              name="addressNumber"
              variant="outlined"
              onChange={(e) => {
                setAddress({ ...address, number: e.target.value });
                onChange({ ...address, number: e.target.value });
              }}
            />
          </Grid>
          <Grid item xs={12} sm={6}>
            <TextField
              disabled
              fullWidth
              value={address.neighborhood}
              label="Bairro"
              name="addressNeighborhood"
              variant="outlined"
              onChange={onChange}
            />
          </Grid>
          <Grid item xs={12} sm={6}>
            <TextField
              fullWidth
              value={address.complement}
              label="Complemento"
              name="addressComplement"
              variant="outlined"
              onChange={(e) => {
                setAddress({ ...address, complement: e.target.value });
                onChange({ ...address, complement: e.target.value });
              }}
            />
          </Grid>
          <Grid item xs={12} sm={6}>
            <TextField
              fullWidth
              value={address.reference}
              label="Referência"
              name="addressReference"
              variant="outlined"
              onChange={(e) => {
                setAddress({ ...address, reference: e.target.value });
                onChange({ ...address, reference: e.target.value });
              }}
            />
          </Grid>
          <Grid item xs={12} sm={6}>
            <TextField
              disabled
              fullWidth
              value={address.city}
              label="Cidade"
              name="addressCity"
              variant="outlined"
              onChange={onChange}
            />
          </Grid>
          <Grid item xs={12} sm={6}>
            <TextField
              disabled
              fullWidth
              value={address.stateCode}
              label="Estado"
              name="addressStateCode"
              variant="outlined"
              onChange={onChange}
            />
          </Grid>

          <Grid item xs={12} sm={6}>
            <TextField
              disabled
              fullWidth
              value={address.countryCode}
              label="País"
              name="addressCountryCode"
              variant="outlined"
              onChange={onChange}
            />
          </Grid>
        </>
      )}
    </Grid>
  );
};

export default AddressForm;