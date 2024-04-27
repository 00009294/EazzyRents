import { UserRole } from "./userRole.enum";

export interface Message {
    content: string;
    timestamp: number;
    //isLandlord: boolean;
    userRole: UserRole;
    realEstateId: number;
}