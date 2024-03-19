import { TOKEN } from "./auth";
import { ROUTER, ROUTER_NAME } from "./router";
const API_URL = import.meta.env.VITE_APP_API_DOMAIN || "http://localhost:8000";
const API_PREFIX = "api";
const VALIDATE_TYPE = {
    'REQUIRED' : 'required',
    'LENGTH' : 'length',
    'ALPPHA_NUM': 'alpha_num',
    'NUM': 'numberic'
}
const RESPONSE_CODE = { 
    UNAUTHORIZED : 401,
    PAYMENTREQUIRED: 402,
    OK: 200
}


export { API_PREFIX, API_URL, TOKEN, ROUTER, VALIDATE_TYPE, RESPONSE_CODE, ROUTER_NAME};
export * from "./dateFormats";
export * from "./order";
