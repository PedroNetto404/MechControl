import React from 'react';
import { Stack, SvgIconTypeMap, Typography } from '@mui/material';
import { OverridableComponent } from '@mui/material/OverridableComponent';

import { CopyButton } from '@/components/shared/copy-button';

type CustomerInfoProps = {
    icon: OverridableComponent<SvgIconTypeMap<{}, 'svg'>> & {
        muiName: string;
    };
    label: React.ReactNode;
    value: string | React.ReactNode;
    canCopy?: boolean;
};

const getTextToCopy: (value: string | React.ReactNode) => string = (value) => {
    if (typeof value === 'string') {
        return value;
    }

    if (React.isValidElement(value)) {
        return React.cloneElement(value as React.ReactElement).props.children as string;
    }

    return '';
};

export const CustomerInfo: React.FC<CustomerInfoProps> = ({ icon: Icon, label, value, canCopy }) => {
    return (
        <Stack direction="row" spacing={2}>
            <Stack direction={'row'} alignItems={'center'} spacing={1}>
                <Icon />
                <Typography variant="body1" fontWeight={'bold'}>
                    {label}:
                </Typography>
            </Stack>
            <Stack direction={'row'} alignItems={'center'} spacing={1}>
                <Typography variant="body1">{value}</Typography>
                {canCopy && <CopyButton text={getTextToCopy(value)} />}
            </Stack>
        </Stack>
    );
};
