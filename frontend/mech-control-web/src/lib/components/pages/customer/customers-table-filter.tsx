"use client";

import { Button, Checkbox, Stack, TextField } from "@mui/material";
import { CustomerType } from "@/types/enums/customer-type";
import {
  Accordion,
  AccordionSummary,
  AccordionDetails,
  Typography,
} from "@mui/material";
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
    <Accordion
      elevation={0}
      defaultExpanded
      sx={{
        ".MuiAccordionSummary-root, .MuiAccordionDetails-root": {
          padding: 0,
          margin: 0,
          width: "100%",
        },
      }}
    >
      <AccordionSummary expandIcon={<ExpandMoreIcon />}>
        <Typography fontSize={18} fontWeight={"bold"}>
          Filtros
        </Typography>
      </AccordionSummary>
      <AccordionDetails>
        <Stack direction="row" gap={2} justifyContent="space-between">
          <TextField
            sx={{
              width: "60%",
            }}
            fullWidth
            label="Pesquise pelo nome, telefone, cpf/cnpj, etc"
            onChange={(e) => onSearchTextChange(e.target.value)}
          />
          <Stack width="40%" direction="row" justifyContent="space-between" gap={2}>
            <Typography fontWeight="bold">Tipo de Cliente</Typography>
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
              <Button
                variant="outlined"
                sx={{
                  marginRight: 2,
                }}
              >
                <ExportIcon /> Exportar
              </Button>
            </Stack>
          </Stack>
        </Stack>
      </AccordionDetails>
    </Accordion>
  );
};
