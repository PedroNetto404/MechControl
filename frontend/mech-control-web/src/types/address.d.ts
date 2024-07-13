export interface Address {
    street: string;
    number: string;
    neighborhood: string;
    city: string;
    stateCode: string;
    zipCode: string;
    countryCode: string;
    complement?: string;
    reference?: string;
}