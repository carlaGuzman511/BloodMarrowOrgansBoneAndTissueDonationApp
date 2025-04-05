import { images, icons } from '@/constants';
import { DonationRequest, Category, Features, User } from '@/models/App.types';

export const features: Features[] = [
    {
        id: 1,
        volume:'6 mmol/L',
        substance:'Glucose'
    },
    {
        id: 2,
        volume:'6.2 mmol/L',
        substance:'Cholesterol'
    },
    {
        id: 3,
        volume:'12 mmol/L',
        substance:'Billirubin'
    },
    {
        id: 4,
        volume:'3.6 ml/L',
        substance:'RBC'
    },
    {
        id: 5,
        volume:'102 fl',
        substance:'MVC'
    },
    {
        id: 6,
        volume:'Platelets',
        substance:'276 bl'
    }
]
export const donors: User[] = [
    {
        id: 1,
        image: images.happyImage,
        name: 'Julia Dunn',
        location: 'Calle Solaris 78, Potosi',
        bloodType: 'AB+'
    },
    {
        id: 2,
        image: images.womanImage,
        name: 'Sonia Miranda',
        location: 'Av. Ballivian 26, Oruro',
        bloodType: 'AB-'
    },
    {
        id: 3,
        image: images.woman2Image,
        name: 'Sandra Diamante',
        location: 'Av. Sopocachi 67, La Paz',
        bloodType: 'O+'
    },
    {
        id: 4,
        image: images.woman1Image,
        name: 'Andrea Perez',
        location: 'Av. America 10, Cochabamba',
        bloodType: 'O-'
    },
    {
        id: 5,
        image: images.boyImage,
        name: 'Sergio Solares',
        location: 'Av. Canioto 40, Santa Cruz',
        bloodType: 'O-'
    },
    {
        id: 6,
        image: images.manImage,
        name: 'Andres Perez',
        location: 'Av. Galindo 550, Cochabamba',
        bloodType: 'AB+'
    },
    {
        id: 7,
        image: images.man1Image,
        name: 'Carlos Savedra',
        location: 'Av. Cotoca 40, Santa Cruz',
        bloodType: 'O-'
    }
]


export const categories: Category[] = [
    {
        icon: icons.findMyFriendIcon,
        title: 'Buscar Donantes'
    },
    {
        icon: icons.organDonation1Icon,
        title: 'Donar'
    },
    {
        icon: icons.orderIcon,
        title: 'Pedir Sangre'
    },
    {
        icon: icons.assistantIcon,
        title: 'Informacion'
    },
    {
        icon: icons.reportIcon,
        title: 'Reportes'
    },
    {
        icon: icons.campaignIcon,
        title: 'Campaña'
    }
]


export const donationRequests: DonationRequest[] = [
    {
        id: 1,
        name: "Karen Siles",
        location: "Hospital Viedma",
        postedDate: "5 min",
        image: icons.bloodDonationIcon,
        donationType: 'Sangre',
        bloodType: 'AB-'
    },
    {
        id: 2,
        name: "Juan Camacho",
        location: "Hospital Viedma",
        postedDate: "15 min",
        image: icons.leucemiaIcon,
        donationType: 'Medula Osea',
        bloodType: 'O-'
    },
    {
        id: 3,
        name: "Nidia Soliz",
        location: "Hospital Cochabamba",
        postedDate: "50 min",
        image: icons.heartDonationIcon,
        donationType: 'Corazón',
        bloodType: 'AB+'
    },
    {
        id: 4,
        name: "Pedro Morales",
        location: "Clinica Los Angeles",
        postedDate: "45 min",
        image: icons.kidneysDonationIcon,
        donationType: 'Riñones',
        bloodType: 'AB+'
    },
    {
        id: 5,
        name: "Maria Mamani",
        location: "Hospital del Norte",
        postedDate: "25 min",
        image: icons.boneIcon,
        donationType: 'Huesos',
        bloodType: 'A+'
    }
]