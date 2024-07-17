import { CarSystem } from "./enums/car-system";
import { FuelType } from "./enums/fuel-type";
import { TransmissionType } from "./enums/transmission-type";

export interface Vehicle {
    id: string;
    plate: string;
    color: string;
    model: string;
    brand: string;
    vin: string;
    manufactoryYear: number;
    currentMileage: number;
    transmission: TransmissionType;
    fuelType: FuelType;
    systemDetails: Readonly<Record<CarSystem, string>>;
}
