'use client';

import * as React from 'react';
import { useMemo, useState } from 'react';
import { useRouter } from 'next/navigation';
import { formatAddress } from '@/utils/address';
import { Delete, Edit } from '@mui/icons-material';
import MoreVertIcon from '@mui/icons-material/MoreVert';
import { alpha, IconButton, ListItemIcon, Menu, MenuItem, MenuProps, styled } from '@mui/material';
import Box from '@mui/material/Box';
import Card from '@mui/material/Card';
import Divider from '@mui/material/Divider';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableHead from '@mui/material/TableHead';
import TablePagination from '@mui/material/TablePagination';
import TableRow from '@mui/material/TableRow';
import dayjs from 'dayjs';

import { Customer, CustomerType } from '@/types';

const StyledMenu = styled((props: MenuProps) => (
    <Menu
        elevation={0}
        anchorOrigin={{
            vertical: 'bottom',
            horizontal: 'right',
        }}
        transformOrigin={{
            vertical: 'top',
            horizontal: 'right',
        }}
        {...props}
    />
))(({ theme }) => ({
    '& .MuiPaper-root': {
        borderRadius: 6,
        marginTop: theme.spacing(1),
        minWidth: 180,
        color: theme.palette.mode === 'light' ? 'rgb(55, 65, 81)' : theme.palette.grey[300],
        boxShadow:
            'rgb(255, 255, 255) 0px 0px 0px 0px, rgba(0, 0, 0, 0.05) 0px 0px 0px 1px, rgba(0, 0, 0, 0.1) 0px 10px 15px -3px, rgba(0, 0, 0, 0.05) 0px 4px 6px -2px',
        '& .MuiMenu-list': {
            padding: '4px 0',
        },
        '& .MuiMenuItem-root': {
            '& .MuiSvgIcon-root': {
                fontSize: 18,
                color: theme.palette.text.secondary,
                marginRight: theme.spacing(1.5),
            },
            '&:active': {
                backgroundColor: alpha(theme.palette.primary.main, theme.palette.action.selectedOpacity),
            },
        },
    },
}));

function noop(): void {}

interface CustomersTableProps {
    count?: number;
    page?: number;
    rows?: Customer[];
    rowsPerPage?: number;
}

export function CustomersTable({
    count = 0,
    rows = [],
    page = 0,
    rowsPerPage = 0,
}: CustomersTableProps): React.JSX.Element {
    const rowIds = useMemo(() => {
        return rows.map((customer) => customer.id);
    }, [rows]);
    const router = useRouter();
    const [currentActions, setCurrentActions] = useState<string | null>(null);
    const [anchorEl, setAnchorEl] = useState<null | HTMLElement>(null);

    const onCellClick = (id: string) => {
        router.push(`/pages/customers/${id}`);
    };

    const handleActionsClick = (event: React.MouseEvent<HTMLElement>, id: string) => {
        setAnchorEl(event.currentTarget);
        setCurrentActions(id);
    };

    const handleClose = () => {
        setAnchorEl(null);
        setCurrentActions(null);
    };

    const ClicableCell = ({ id, children }: { id: string; children: React.ReactNode }) => (
        <TableCell
            onClick={() => onCellClick(id)}
            sx={{
                '&:hover': {
                    cursor: 'pointer',
                },
            }}
        >
            {children}
        </TableCell>
    );

    return (
        <Card>
            <Box sx={{ overflowX: 'auto' }}>
                <Table sx={{ minWidth: '800px' }}>
                    <TableHead>
                        <TableRow>
                            <TableCell>Nome</TableCell>
                            <TableCell>Email</TableCell>
                            <TableCell>Celular</TableCell>
                            <TableCell>CPF/CNPJ</TableCell>
                            <TableCell>Tipo</TableCell>
                            <TableCell>Endereço</TableCell>
                            <TableCell>Registrado em</TableCell>
                            <TableCell>Ações</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {rows.map((row) => {
                            return (
                                <TableRow
                                    sx={{
                                        '&:hover': {
                                            cursor: 'pointer',
                                        },
                                    }}
                                    hover
                                    key={row.id}
                                >
                                    <ClicableCell id={row.id}>{row.fullName}</ClicableCell>
                                    <ClicableCell id={row.id}>{row.email}</ClicableCell>
                                    <ClicableCell id={row.id}>{row.phone}</ClicableCell>
                                    <ClicableCell id={row.id}>{row.document}</ClicableCell>
                                    <ClicableCell id={row.id}>
                                        {row.type === CustomerType.Individual ? 'Pessoa Física' : 'Pessoa Jurídica'}
                                    </ClicableCell>
                                    <ClicableCell id={row.id}>{formatAddress(row.address)}</ClicableCell>
                                    <ClicableCell id={row.id}>
                                        {dayjs(row.createdOnUtc).format('DD/MM/YYYY')}
                                    </ClicableCell>
                                    <TableCell>
                                        <IconButton
                                            aria-label="actions"
                                            onClick={(event) => handleActionsClick(event, row.id)}
                                            size="small"
                                            aria-haspopup="true"
                                            aria-expanded={currentActions === row.id ? 'true' : undefined}
                                        >
                                            <MoreVertIcon />
                                        </IconButton>
                                        <StyledMenu
                                            anchorEl={anchorEl}
                                            open={currentActions === row.id}
                                            onClose={handleClose}
                                            anchorOrigin={{
                                                vertical: 'bottom',
                                                horizontal: 'right',
                                            }}
                                            transformOrigin={{
                                                vertical: 'top',
                                                horizontal: 'right',
                                            }}
                                        >
                                            <MenuItem onClick={handleClose}>
                                                <ListItemIcon>
                                                    <Edit fontSize="small" />
                                                </ListItemIcon>
                                                Editar
                                            </MenuItem>
                                            <MenuItem onClick={handleClose}>
                                                <ListItemIcon>
                                                    <Delete fontSize="small" />
                                                </ListItemIcon>
                                                Excluir
                                            </MenuItem>
                                        </StyledMenu>
                                    </TableCell>
                                </TableRow>
                            );
                        })}
                    </TableBody>
                </Table>
            </Box>
            <Divider />
            <TablePagination
                component="div"
                count={count}
                onPageChange={noop}
                onRowsPerPageChange={noop}
                page={page}
                rowsPerPage={rowsPerPage}
                rowsPerPageOptions={[5, 10, 25]}
            />
        </Card>
    );
}
