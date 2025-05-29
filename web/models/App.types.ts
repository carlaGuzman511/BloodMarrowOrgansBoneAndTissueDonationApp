export type Comment = {
    id?: number,
    description: string,
    donationPostId?: string,
    createdAt?: string,
    updatedAt?: string,
}

export type Donation = {
    id: number,
    name: string,
    description: string,
    requirements: string,
    process: string,
    importance: string,
    benefits: string,
    secondaryEffects: string,
    image?: string,
}

export type DonationPost = {
    id?: string,
    description: string,    
    bloodTypeId?: string,
    bloodType?: BloodType,
    donationTypeId?: string,
    donationType?: Donation,
    userId?: string,
    user?: User,    
    donationCenterId?: string,
    donationCenter?: DonationCenter,
    comments: Comment[],
    image?: string,
    createdAt: string,
    updatedAt: string,
}

export type User = {
    id: number,
    fullName: string,
    email: string,
    bloodTypeId: string,
    password: string,
    address: string,
    phoneNumber: string,
    image?: string,
    dateOfBirth: string,
    latitude: number,
    longitude: number,
    donationPosts?: Donation[],
}

export type BloodType = {
    id?: number,
    name: string,       
    image: string,
}

export type DonationCenter = {
    id: number,
    name: string,
    address: string,
    image: string,
    city: string,
    latitude: number,
    longitude: number,
    donationTypes?: Donation[],
    donationTypeIds?: number[],
}

export enum Status {
    Active = 1,
    Inactive = 2
}

export type Props = {
    children?: React.ReactNode;
};
