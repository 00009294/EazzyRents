import { Address } from "./address";
import { RealEstateStatusModel } from "./realestatestatus.enum";

export interface AddRealEstateModel{
    Id: number;
    Description: any | null;
    About: string;
    Price: any | null;
    PhoneNumber: any | null,
    ImageDataList: FormData;
    Address: Address;
    Longitude: string,
    Latitude: string,
    Email: string,
    RealEstateStatus: RealEstateStatusModel,
    Owner: string | null
}