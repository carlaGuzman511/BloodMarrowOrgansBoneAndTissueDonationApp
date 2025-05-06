import { Tabs } from "expo-router";
import React from "react";
import { StatusBar } from "expo-status-bar";
import { MaterialCommunityIcons, AntDesign, Entypo } from "@expo/vector-icons";
import { COLORS } from "@/constants";

export default function RootLayout() {
  return (
    <>
      <StatusBar style="auto" />
      <Tabs 
        screenOptions={{
          tabBarActiveTintColor: COLORS.green,
      }}>
        <Tabs.Screen 
          name="home"  
          options={{
            title:"Home",
            href:"/",
            tabBarLabel: "Home",
            tabBarIcon: ({color, focused}: any) => (
              <MaterialCommunityIcons
                name="home"
                size={24}
                color={color}
                focused={focused}
                />
            ),
          }}  
        />
        <Tabs.Screen 
          name="search"  
          options={{
            tabBarBadge:4,
            headerShown: false,
            tabBarBadgeStyle:{
              backgroundColor: "tomato",
              color:"white",
            },
            title:"Search",
            tabBarLabel: "Search",
            tabBarIcon: ({color, focused}: any) => (
              <AntDesign 
                name="search1"
                size={24}
                color={color}
                focused={focused}
              />
            ),
          }}
        />
        <Tabs.Screen 
          name="profile" 
          options={{
            title:"Profile",
            tabBarLabel: "Profile",
            tabBarIcon: ({color, focused}: any) => (
              <AntDesign 
                name="user" 
                size={24}
                color={color}
                focused={focused}
              />
            ),
          }}
        />
        <Tabs.Screen 
          name="information" 
          options={{
            title:"Information",
            headerShown: false,
            tabBarLabel: "Information",
            tabBarIcon: ({color, focused}: any) => (
              <MaterialCommunityIcons 
                name="book-education-outline" 
                size={24}
                color={color}
                focused={focused}
              />
            ),
          }}
        />
        <Tabs.Screen 
          name="reports"  
          options={{
            title:"Reports",
            headerShown: false,
            tabBarLabel: "Reports",
            tabBarIcon: ({color, focused}: any) => (
              <Entypo 
                name="line-graph" 
                size={24}
                color={color}
                focused={focused}
              />                 
            ),
          }}
        />
    </Tabs>
    </>
  );
} 