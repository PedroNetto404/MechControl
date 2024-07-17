import { CustomerType } from "./enums/customer-type";

export interface Customer {
  id: string;
  firstName: string;
  middleName: string;
  isMei?: boolean;
  birthDate?: Date;
  lastName: string;
  email: string;
  phone: string;
  addressStreet: string;
  addressNumber: string;
  addressNeighborhood: string;
  addressComplement?: string;
  addressReference?: string;
  addressCity: string;
  addressCountryCode: string;
  addressStateCode: string;
  addressZipCode: string;
  document: Document;
  mechShopId: string;
  createdOnUtc: Date;
  modifiedOnUtc: Date;
  type: CustomerType;
  age(): number;
}

export function getAge(birthDate: Date): number {
  const today = new Date();
  const birthDateYear = birthDate.getFullYear();
  const todayYear = today.getFullYear();
  const age = todayYear - birthDateYear;
  const birthDateMonth = birthDate.getMonth();
  const todayMonth = today.getMonth();
  if (todayMonth < birthDateMonth) {
    return age - 1;
  }
  if (todayMonth === birthDateMonth) {
    const birthDateDay = birthDate.getDate();
    const todayDay = today.getDate();
    if (todayDay < birthDateDay) {
      return age - 1;
    }
  }
  return age;
}