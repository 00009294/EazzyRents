import { NonNullAssert } from "@angular/compiler";
import { Address } from "./address";

export interface RealEstateModel{
    id: number;
    description: string | null;
    about: string | null;
    price: string | null;
    phoneNumber: string | null,
    imageUrls: string[];
    address: Address;
    longitude: string,
    latitude: string,
    owner: string | null
}