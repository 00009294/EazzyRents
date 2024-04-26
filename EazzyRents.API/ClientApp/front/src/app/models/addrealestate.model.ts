import { Address } from "./address";
import { RealEstateStatusModel } from "./realestatestatus.enum";

export interface AddRealEstateModel{
    Id: number;
    Description: any | null;
    About: any;
    Price: any | null;
    PhoneNumber: any | null,
    ImageDataList: string[] | any;
    Address: Address;
    Longitude: string,
    Latitude: string,
    Email: string,
    RealEstateStatusModel: RealEstateStatusModel,
    Owner: string | null
}