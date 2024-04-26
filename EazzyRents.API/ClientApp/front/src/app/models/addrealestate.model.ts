import { Address } from "./address";

export interface AddRealEstateModel{
    Id: number;
    Description: any | null;
    About: any;
    Price: any | null;
    PhoneNumber: any | null,
    ImageDataList: any | null;
    Address: Address;
    Longitude: string,
    Latitude: string,
    Email: string,
    RealEstateStatus: any,
    Owner: string | null
}