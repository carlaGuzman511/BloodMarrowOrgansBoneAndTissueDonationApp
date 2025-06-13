import { GestureHandlerRootView } from 'react-native-gesture-handler';
import Home from '@/screens/Home';
import { InformationContextProvider } from './context';

export default function Information() {
  return (
    <GestureHandlerRootView>
      <InformationContextProvider>
        <Home />
      </InformationContextProvider>
    </GestureHandlerRootView>
  );
}
