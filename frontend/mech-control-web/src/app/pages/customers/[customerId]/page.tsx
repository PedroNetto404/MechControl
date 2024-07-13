import customers from '@/sample';
import { formatAddress } from '@/utils/address';
import BadgeIcon from '@mui/icons-material/Badge';
import EditIcon from '@mui/icons-material/Edit';
import EmailIcon from '@mui/icons-material/Email';
import HomeIcon from '@mui/icons-material/Home';
import LocalPhoneIcon from '@mui/icons-material/LocalPhone';
import { Button, Card, CardContent, CardHeader, IconButton, Link, Stack, Typography } from '@mui/material';

import { CustomerType } from '@/types';
import { CustomerInfo } from '@/components/pages/customer/customer-info';

const Page: React.FC<{
    params: {
        customerId: string;
    };
}> = ({ params: { customerId } }) => {
    const customer = customers.find((customer) => customer.id === customerId)!;
    const addressLine = formatAddress(customer.address);
    return (
        <Card>
            <CardHeader
                title={<Typography variant="h3">{customer.fullName}</Typography>}
                subheader={customer.email}
                action={
                    <Stack direction="row" spacing={2}>
                        <IconButton>
                            <EditIcon />
                        </IconButton>
                    </Stack>
                }
            />
            <CardContent>
                <Stack direction={'column'} gap={2}>
                    <Typography variant="h5">Informações</Typography>
                    <CustomerInfo icon={EditIcon} label="Nome" value={customer.fullName} />
                    <CustomerInfo
                        icon={BadgeIcon}
                        label={customer.type === CustomerType.Individual ? 'CPF' : 'CNPJ'}
                        value={customer.document}
                        canCopy
                    />
                    <CustomerInfo icon={EmailIcon} label="Email" value={customer.email} canCopy />
                    <CustomerInfo icon={LocalPhoneIcon} label="Celular" value={customer.phone} canCopy />
                    <CustomerInfo
                        canCopy
                        icon={HomeIcon}
                        label="Endereço"
                        value={
                            <Link
                                href={`https://www.google.com/maps/search/?api=1&query=${addressLine}`}
                                target="_blank"
                                rel="noreferrer"
                            >
                                {addressLine}
                            </Link>
                        }
                    />
                </Stack>
            </CardContent>
        </Card>
    );
};

export default Page;
