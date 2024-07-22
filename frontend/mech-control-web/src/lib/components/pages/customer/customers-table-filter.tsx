"use client";

import { Button, Checkbox, Stack, TextField } from "@mui/material";
import { CustomerType } from "@/types/enums/customer-type";
import { Typography } from "@mui/material";
import ExpandMoreIcon from "@mui/icons-material/ExpandMore";
import ExportIcon from "@mui/icons-material/Download";
import { useState } from "react";

type CustomerTypeCheckProps = {
  label: string;
  onClick: () => void;
  checked: boolean;
};

const CustomerTypeCheck: React.FC<CustomerTypeCheckProps> = ({
  onClick,
  label,
  checked,
}) => (
  <Stack direction="row" justifyContent="space-between" alignItems="center">
    <Typography>{label}</Typography>
    <Checkbox checked={checked} onClick={onClick} />
  </Stack>
);

type CustomersTableFilterProps = {
  onSearchTextChange: (searchText: string) => void;
  onCustomerTypeChange: (customerType: CustomerType, selected: boolean) => void;
};

export const CustomersTableFilter: React.FC<CustomersTableFilterProps> = ({
  onSearchTextChange,
  onCustomerTypeChange,
}) => {
  const [showIndividualCustomer, setShowIndividualCustomer] = useState(true);
  const [showCorporateCustomer, setShowCorporateCustomer] = useState(true);

  return (
    <Stack
      sx={{
        paddingBottom: 2,
      }}
    >
      <Stack direction="row" justifyContent={"space-between"}>
        <Typography fontSize={18} fontWeight={"bold"} py={2}>
          Filtros
        </Typography>
        <Button
          variant="outlined"
          sx={{
            marginRight: 2,
          }}
        >
          <ExportIcon /> Exportar
        </Button>
      </Stack>
      <Stack direction="column" gap={2} justifyContent="space-between">
        <TextField
          sx={{
            width: "60%",
          }}
          fullWidth
          label="Pesquise pelo nome, telefone, cpf/cnpj, etc"
          onChange={(e) => onSearchTextChange(e.target.value)}
        />
        <Stack
          width="40%"
          direction="row"
          justifyContent="space-between"
          gap={2}
        >
          <Stack direction="row" alignItems="start">
            <CustomerTypeCheck
              onClick={() => {
                const show = !showIndividualCustomer;
                onCustomerTypeChange(CustomerType.individual, show);
                setShowIndividualCustomer(show);
              }}
              checked={showIndividualCustomer}
              label="Pessoa Física"
            />
            <CustomerTypeCheck
              onClick={() => {
                const show = !showCorporateCustomer;
                onCustomerTypeChange(CustomerType.corporate, show);
                setShowCorporateCustomer(show);
              }}
              checked={showCorporateCustomer}
              label="Pessoa Jurídica"
            />
          </Stack>
        </Stack>
      </Stack>
    </Stack>
  );
};
