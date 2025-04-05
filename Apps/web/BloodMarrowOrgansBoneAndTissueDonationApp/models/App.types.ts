import { ImageSourcePropType } from "react-native";

export type Category = {
    icon: ImageSourcePropType,
    title: string
}

export type Features = {
    id: number,
    volume: string,
    substance: string
}

export type DonationRequest = {
    id: number,
    name: string,
    location: string,
    postedDate: string,
    bloodType: string,
    image: ImageSourcePropType,
    donationType?: string
}

export type User = {
    id: number,
    name: string,
    location: string,
    bloodType: string,
    image: ImageSourcePropType,
}

export interface Post {
    id: number;
    title: string;
    description: string;
    image: string;
    postDate: string;
    accountId: number;
    donationTypeId: number;
    postTypeId: number;
    statusId: Status;
}

export interface Person {
    id: number;
    firstName: string;
    lastName: string;
    birthDate: string
    bloodType: BloodType;
    image: string;
    phoneNumber: string;
    address: string;
    ci: string;
}

export interface Comment {
    id: number;
    description: string;
    postId: number;
    dateAdded: string;
    dateChanged: string;
}

export interface Account {
    id: number;
    person: Person;
    userName: string;
    password: string;
}

export enum Status {
    Active = 1,
    Inactive = 2
}

export enum PostType {
    Donacion = 1,
    'Busqueda de Personas Desaparecidas' = 2,
    Accidentes = 3,
    Incidentes = 4
}

export enum DonationType {
    Riñón = 1,
    Hígado = 2,
    Pulmón = 3,
    Páncreas = 4,
    'Intestino Delgado' = 5,
    Corazón = 6,
    Corneas = 7,
    Huesos = 8,
    Piel = 9,
    Tendones = 10, 
    'Medula Osea' = 11,
    Sangre = 12,
    'Intestino Grueso' = 5,
}

export enum BloodType {
    'A+' = 1,
    'A-' = 2,
    'B+' = 3,
    'B-' = 4,
    'AB+' = 5,
    'AB-' = 6,
    'O+' = 7,
    'O-' = 8,
}

export type Props = {
    children?: React.ReactNode;
};
