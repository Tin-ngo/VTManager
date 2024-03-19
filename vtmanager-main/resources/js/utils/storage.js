import { TOKEN } from "@/constants/auth";

/**
 * Get token cookie
 * @returns string|null token
 */
export function getToken() {
  return localStorage.getItem(TOKEN.ACCESS_TOKEN);
}
