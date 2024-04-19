import { Address } from "./address";

export interface RealEstateModel{
    id: number;
    description: string;
    about: string;
    price: string;
    phoneNumber: string,
    imageUrls: string[];
    address: Address;
    longitude: number,
    latitude: number,
    owner: string
}