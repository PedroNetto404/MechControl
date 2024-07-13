export interface Vehicle {
    id: string;
    brand: string;
    model: string;
    year: Number;
    plate: string;
    color: string;
    createdOnUtc: Date;
    modifiedOnUtc: Date;
    ownerId: string;
    pictureUrl: string;
}