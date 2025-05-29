import { GestureHandlerRootView } from 'react-native-gesture-handler';
import Home from '@/screens/Home';

export default function Information() {
  return (
    <GestureHandlerRootView>
      <Home />
      {/* <View
        style={{
          flex: 1,
          justifyContent: "center",
          alignItems: "center",
        }}
      >
        <Text>
          Information  
        </Text>
        
        <Link 
          href="/information/Blood"
          push asChild
        >
          <Button
            title="Push to Blood"
          />
        </Link>
        <Link 
          href="/information/Heart"
          push asChild
        >
          <Button
            title="Push to Heart"
          />
        </Link>
        <Link 
          href="/information/Kidneys"
          push asChild
        >
          <Button
            title="Push to Kidneys"
          />
        </Link>
        <Link 
          href="/information/Marrow"
          push asChild
        >
          <Button
            title="Push to Marrow"
          />
        </Link>
        <Link 
          href="/information/Tissue"
          push asChild
        >
          <Button
            title="Push to Tissue"
          />
        </Link> 
      </View>*/}
    </GestureHandlerRootView>
  );
}
