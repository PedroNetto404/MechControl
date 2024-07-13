'use client';

import * as React from 'react';
import { Box, Checkbox, FormControl, FormControlLabel, FormLabel } from '@mui/material';
import Card from '@mui/material/Card';
import InputAdornment from '@mui/material/InputAdornment';
import OutlinedInput from '@mui/material/OutlinedInput';
import { MagnifyingGlass as MagnifyingGlassIcon } from '@phosphor-icons/react/dist/ssr/MagnifyingGlass';

import { CustomerType } from '@/types';

type CustomersFiltersProps = {
    onSearchChange: (event: React.ChangeEvent<HTMLInputElement>) => void;
    onTypeChange: (selectedTypes: CustomerType[]) => void;
};

export const CustomersFilters: React.FC<CustomersFiltersProps> = ({ onSearchChange, onTypeChange }) => {
    const [selectedTypes, setSelectedTypes] = React.useState<CustomerType[]>([
        CustomerType.Individual,
        CustomerType.Corporate,
    ]);

    const handleTypeChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        const value = event.target.value as CustomerType;
        const updatedTypes = selectedTypes.includes(value)
            ? selectedTypes.filter((type) => type !== value)
            : [...selectedTypes, value];
        setSelectedTypes(updatedTypes);
        onTypeChange(updatedTypes);
    };

    return (
        <Card sx={{ p: 2 }}>
            <Box sx={{ display: 'flex', flexDirection: 'row', gap: 3 }}>
                <OutlinedInput
                    onChange={onSearchChange}
                    defaultValue=""
                    fullWidth
                    placeholder="Pesquise pelo nome, email ou telefone"
                    startAdornment={
                        <InputAdornment position="start">
                            <MagnifyingGlassIcon fontSize="var(--icon-fontSize-md)" />
                        </InputAdornment>
                    }
                    sx={{ maxWidth: '500px' }}
                />
                <FormControl component="fieldset">
                    <FormLabel component="legend">Tipo de Cliente</FormLabel>
                    <Box>
                        <FormControlLabel
                            control={
                                <Checkbox
                                    checked={selectedTypes.includes(CustomerType.Individual)}
                                    onChange={handleTypeChange}
                                    value={CustomerType.Individual}
                                />
                            }
                            label="Pessoa Física"
                        />
                        <FormControlLabel
                            control={
                                <Checkbox
                                    checked={selectedTypes.includes(CustomerType.Corporate)}
                                    onChange={handleTypeChange}
                                    value={CustomerType.Corporate}
                                />
                            }
                            label="Pessoa Jurídica"
                        />
                    </Box>
                </FormControl>
            </Box>
        </Card>
    );
};
