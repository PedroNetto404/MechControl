import {
    Address,
    CustomerType,
    Vehicle
} from './index';

interface Customer {
    id: string;
    firstName: string;
    lastName: string;
    fullName: string;
    email: string;
    phone: string;
    address: Address;    
    type: CustomerType;
    mechShopId: string;
    document: string;
    createdOnUtc: Date;
    modifiedOnUtc: Date;
    birthDate?: Date;
    isMei?: boolean;
    vehicles: Vehicle[];
}