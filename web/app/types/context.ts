import { Donation, DonationCenter, DonationPost } from "@/models/App.types";

export type Action = {
  type: string;
  payload: any;
};

export type InformationStateType = {
  information: Donation[];
};

export type InformationContextType = {
  information: Donation[];
};

export type SearchStateType = {
  donationCenters: DonationCenter[];
};

export type SearchContextType = {
  donationCenters: DonationCenter[];
};


export type HomeStateType = {
  donationPosts: DonationPost[];
};

export type HomeContextType = {
  donationPosts: DonationPost[];
};