import Slider from "@/components/Slider";
import {images} from "@/constants";
import { useLocalSearchParams } from 'expo-router';
import { GestureHandlerRootView } from 'react-native-gesture-handler';

export default function Details() {
  const { name, description, requirements, process, importance, benefits, secondaryEffects } = useLocalSearchParams();
  const data: any[]= [
    {
      name: name,
      image: images.a,
      description: description,
    },
    {
      name: 'Requerimientos',
      image: images.descarga,
      description: requirements,
    },
    {
      name: 'Proceso',
      image: images.donacionOrganos,
      description: process,
    },
    {
      name: 'Importancia',
      image: images.b,
      description: importance,
    },
    {
      name: 'Beneficios',
      image: images.beneficios1,
      description: benefits,
    },
    {
      name: 'Efectos Secundarios',
      image: images.b,
      description: secondaryEffects,
    }
  ];
  
  return (
    <GestureHandlerRootView>
      <Slider data={data} />
    </GestureHandlerRootView>
  );
}
