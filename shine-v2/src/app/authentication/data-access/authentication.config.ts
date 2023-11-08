import * as Msal from 'msal';

export const config: Msal.Configuration = {
    auth: {
      clientId: '3eea5a6b-cc13-4f0e-b797-b32dfade784a',
      authority: 'https://login.microsoftonline.com/94a2fec0-9f74-4b78-973c-8985b3bd36f9',
      redirectUri: 'http://localhost:4200/internships', // Same as the one you registered in Azure AD
    },
    cache: {
      cacheLocation: 'localStorage', // Use 'localStorage' or 'sessionStorage'
      storeAuthStateInCookie: false,
    },
  };