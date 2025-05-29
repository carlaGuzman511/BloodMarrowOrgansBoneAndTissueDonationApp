import { images } from '@/constants';
import { Category, Features, User } from '@/models/App.types';

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
        image: images.give4Life2,
        name: 'Julia Dunn',
        location: 'Calle Solaris 78, Potosi',
        bloodType: 'AB+'
    },
    {
        id: 2,
        image: images.give4Life2,
        name: 'Sonia Miranda',
        location: 'Av. Ballivian 26, Oruro',
        bloodType: 'AB-'
    },
    {
        id: 3,
        image: images.give4Life2,
        name: 'Sandra Diamante',
        location: 'Av. Sopocachi 67, La Paz',
        bloodType: 'O+'
    },
    {
        id: 4,
        image: images.give4Life2,
        name: 'Andrea Perez',
        location: 'Av. America 10, Cochabamba',
        bloodType: 'O-'
    },
    {
        id: 5,
        image: images.give4Life2,
        name: 'Sergio Solares',
        location: 'Av. Canioto 40, Santa Cruz',
        bloodType: 'O-'
    },
    {
        id: 6,
        image: images.give4Life2,
        name: 'Andres Perez',
        location: 'Av. Galindo 550, Cochabamba',
        bloodType: 'AB+'
    },
    {
        id: 7,
        image: images.give4Life2,
        name: 'Carlos Savedra',
        location: 'Av. Cotoca 40, Santa Cruz',
        bloodType: 'O-'
    }
]


export const categories: Category[] = [
    {
        icon: images.give4Life2,
        title: 'Buscar Donantes'
    },
    {
        icon: images.give4Life2,
        title: 'Donar'
    },
    {
        icon: images.give4Life2,
        title: 'Pedir Sangre'
    },
    {
        icon: images.give4Life2,
        title: 'Informacion'
    },
    {
        icon: images.give4Life2,
        title: 'Reportes'
    },
    {
        icon: images.give4Life2,
        title: 'Campaña'
    }
]

