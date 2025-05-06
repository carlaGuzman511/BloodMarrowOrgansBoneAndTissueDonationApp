import axios from "axios";
import Constants from "expo-constants";

export const api = axios.create({
  // baseURL: Constants.expoConfig?.extra?.API_URL,
  baseURL: "https://192.168.150.5:7140", 
  timeout: 10000,
});
