import React, { useState } from "react";
import {
  Paper,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
} from "@mui/material";
import { Customer, getAge } from "@/types/customer";

interface CustomersTableProps {
  customers: Customer[];
  totalCount: number;
}

export const CustomersTable: React.FC<CustomersTableProps> = ({
  customers,
  totalCount,
}) => {
  return (
    <Paper>
      <TableContainer>
        <Table>
          <TableHead>
            <TableRow>
              <TableCell>Código</TableCell>
              <TableCell>Primeiro Nome</TableCell>
              <TableCell>Último Nome</TableCell>
              <TableCell>Email</TableCell>
              <TableCell>Telefone</TableCell>
              <TableCell>Endereço</TableCell>
              <TableCell>Data de Nascimento</TableCell>
              <TableCell>Idade</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {customers.map((customer) => (
              <TableRow key={customer.id}>
                <TableCell>{customer.firstName}</TableCell>
                <TableCell>{customer.lastName}</TableCell>
                <TableCell>{customer.email}</TableCell>
                <TableCell>{customer.phone}</TableCell>
                <TableCell>{`${customer.addressStreet}, ${customer.addressNumber}, ${customer.addressNeighborhood}, ${customer.addressCity}, ${customer.addressStateCode}, ${customer.addressZipCode}`}</TableCell>
                <TableCell>
                  {customer.birthDate
                    ? new Date(customer.birthDate).toLocaleDateString()
                    : "N/A"}
                </TableCell>
                <TableCell>
                  {customer.birthDate
                    ? getAge(new Date(customer.birthDate))
                    : "N/A"}
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    </Paper>
  );
};
