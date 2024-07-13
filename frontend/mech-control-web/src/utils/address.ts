import { Address } from '@/types';

export function formatAddress(address: Address): string {
    return `${address.street}, ${address.number} - ${address.neighborhood}, ${address.city} - ${address.stateCode}, ${address.zipCode}`;
}
