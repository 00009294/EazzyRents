import { UserRole } from "./userRole.enum";

export interface ProfileModel{
    id: string,
    userName: string;
    email: string;
    userRole: UserRole;
}