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
import { DataGrid, GridColDef } from "@mui/x-data-grid";
import { CustomerType } from "@/types/enums/customer-type";

const columns: GridColDef<Customer>[] = [
  {
    field: "id",
    headerName: "Código",
    width: 70,
  },
  {
    field: "name",
    headerName: "Nome",
    width: 200,
  },
  {
    field: "type",
    headerName: "Tipo",
    width: 120,
    valueGetter: (value, row) =>
      row.type === CustomerType.corporate ? "Pessoa Jurídica" : "Pessoa Física",
  },
  {
    field: "document",
    headerName: "Documento",
  },
  {
    field: "phone",
    headerName: "Telefone",
    width: 100,
  },
  {
    field: "email",
    headerName: "E-mail",
    width: 200,
  },
];

interface CustomersTableProps {
  customers: Customer[];
  totalCount: number;
  onPaginationChange: (page: number, pageSize: number) => void;
  onCustomerClick: (customerId: string) => void;
}

export const CustomersTable: React.FC<CustomersTableProps> = ({
  customers,
  totalCount,
  onPaginationChange,
  onCustomerClick,
}) => (
  <div
    style={{
      height: 400,
      width: "100%",
    }}
  >
    <DataGrid
      columns={columns}
      rows={customers}
      onPaginationModelChange={(model) => {
        onPaginationChange(model.page, model.pageSize);
      }}
      onRowClick={({ row }) => onCustomerClick(row.id)}
      pageSizeOptions={[5, 10, 15]}
      rowCount={totalCount}
      initialState={{
        pagination: {
          paginationModel: {
            page: 0,
            pageSize: 10,
          },
        },
      }}
    />
  </div>
);
