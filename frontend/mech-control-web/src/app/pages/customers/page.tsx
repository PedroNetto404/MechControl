'use client';

import * as React from 'react';
import { useEffect, useState } from 'react';
import customers from '@/sample';
import Button from '@mui/material/Button';
import Stack from '@mui/material/Stack';
import Typography from '@mui/material/Typography';
import { Download as DownloadIcon } from '@phosphor-icons/react/dist/ssr/Download';
import { Plus as PlusIcon } from '@phosphor-icons/react/dist/ssr/Plus';

import { Customer, CustomerType } from '@/types';
import { CustomersFilters } from '@/components/pages/customer/customers-filters';
import { CustomersTable } from '@/components/pages/customer/customers-table';

const Page: React.FC = () => {
    const [customersInTable, setCustomersInTable] = useState(customers);

    const page = 0;
    const rowsPerPage = 15;

    useEffect(() => {
        const paginatedCustomers = applyPagination(customers, page, rowsPerPage);
        setCustomersInTable(paginatedCustomers);
    }, []);

    const onSearchChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        const search = event.target.value.toLowerCase();
        const filteredCustomers = customers.filter(
            (customer) =>
                customer.fullName.toLowerCase().includes(search) ||
                customer.email.toLowerCase().includes(search) ||
                customer.phone.toLowerCase().includes(search)
        );

        var paginatedCustomers = applyPagination(filteredCustomers, page, rowsPerPage);
        setCustomersInTable(paginatedCustomers);
    };

    const onCustomerTypesChange = (selectedTypes: CustomerType[]) => {
        const filteredCustomers = customers.filter((customer) => selectedTypes.includes(customer.type));
        var paginatedCustomers = applyPagination(filteredCustomers, page, rowsPerPage);
        setCustomersInTable(paginatedCustomers);
    };

    return (
        <Stack spacing={3}>
            <Stack direction="row" spacing={3}>
                <Stack spacing={1} sx={{ flex: '1 1 auto' }}>
                    <Typography variant="h4">Clientes</Typography>
                    <Stack direction="row" spacing={1} sx={{ alignItems: 'center' }}></Stack>
                </Stack>
                <Stack direction="row" spacing={1}>
                    <Button
                        variant="outlined"
                        color="inherit"
                        startIcon={<DownloadIcon fontSize="var(--icon-fontSize-md)" />}
                    >
                        Exportar
                    </Button>
                    <Button startIcon={<PlusIcon fontSize="var(--icon-fontSize-md)" />} variant="contained">
                        Adicionar
                    </Button>
                </Stack>
            </Stack>
            <CustomersFilters onSearchChange={onSearchChange} onTypeChange={onCustomerTypesChange} />
            <CustomersTable
                count={customersInTable.length}
                page={page}
                rows={customersInTable}
                rowsPerPage={rowsPerPage}
            />
        </Stack>
    );
};

function applyPagination(rows: Customer[], page: number, rowsPerPage: number): Customer[] {
    return rows.slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage);
}

export default Page;
