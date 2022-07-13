
import { createBottomTabNavigator, Ionicons, tabBarIcon} from '@react-navigation/bottom-tabs';
import Cart from '../screens/Cart';
import Home from '../screens/Home';
import Profile from '../screens/Profile'

const Tab = createBottomTabNavigator();

export default function Tabs() {
    return (
      <Tab.Navigator>
        <Tab.Screen name="Home" component={Home} options={{ headerShown: false,  }} />
        <Tab.Screen name="Cart" component={Cart} options={{ headerShown: false }} />
        <Tab.Screen name="Profile" component={Profile} options={{ headerShown: false }} />
      </Tab.Navigator>
    );
}