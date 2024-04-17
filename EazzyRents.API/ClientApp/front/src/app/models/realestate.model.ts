import { Address } from "./address";

export interface RealEstateModel{
    id: number;
    description: any;
    price: any;
    imageUrls: string[];
    address: Address;
    longitude: number,
    latitude: number
}