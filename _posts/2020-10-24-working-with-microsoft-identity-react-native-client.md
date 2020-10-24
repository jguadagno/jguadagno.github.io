---
title: "Working with Microsoft Identity - React Native Client"
header:
    og_image: /assets/images/posts/header/msal-react-native.png
categories:
  - Articles
tags:
  - Azure
  - Identity
  - MSAL
  - Managed Identity
  - React Native
---

In this post, I'm going to walk through how you authenticate and use an API that is secured with Azure Active Directory using React Native and the Microsoft Identity library.

> This blog post demonstrates connecting to the Contact API that I have been building on my stream  [Coding with JoeG](https://jjg.me/stream). The API project can be found in the [Contacts](https://github.com/jguadagno/contacts) Repository. While the code will build, it will not run because you will need the client application registered in Azure with the correct permissions.

You can view the following [Introduction to React Native](https://youtu.be/IScDA7cKsSM) video recording from my stream.  You can also watch me code this live on [Building the API Client and Authentication](https://youtu.be/9Wot8p9bWf4).

Completed code repository at [https://github.com/jguadagno/contacts-react-native-client](https://github.com/jguadagno/contacts-react-native-client)

## Prerequisites

This blog post assumes that you have certain tools installed and are familiar with them. If you don't have the tools installed, I have provided a quick guide and links to get you started.

### Node.js

Visit the Node.js [installation](https://nodejs.org/en/){:target="_blank"} for details on installing Node.js.

After node.js is installed, you can optionally load the required packages that will be used later ahead of time so the installation goes faster.

```bash
npm install -g expo-cli msal @openapitools/openapi-generator-cli @react-native-community/masked-view react-native-gesture-handler react-native-reanimated react-native-screens react-native-safe-area-context @react-navigation/native @react-navigation/stack axios url
```

or with Yarn

```bash
yarn global add expo-cli msal @openapitools/openapi-generator-cli @react-native-community/masked-view react-native-gesture-handler react-native-reanimated react-native-screens react-native-safe-area-context @react-navigation/native @react-navigation/stack axios url
```

### React Native

Installing React Native

* [React Native](https://reactnative.dev/){:target="_blank"}
* [Setting up your environment](https://reactnative.dev/docs/environment-setup){:target="_blank"}

Once installed, add the expo cli to your project.

```bash
yarn add expo-cli
```

### Generate React Native Application

To generate the React Native application, execute the following commands in your terminal or command prompt. Replace `my-app` with the name you want to call your application.

```bash
# Create the React Native project using the TypeScript template
npx create-react-native-app my-app --template with-typescript
# Install additional React Native tools: React Navigation
yarn add @react-navigation/native @react-navigation/stack
```

### Setup OpenAPI Generator

The [OpenAPI Generator](https://github.com/OpenAPITools/openapi-generator){:target="_blank"} is used to generate an API client for the React Native application to use.  You can pick from a few different [generators](https://openapi-generator.tech/docs/generators) but for this example, I am using the [Axios](https://github.com/axios/axios){:target="_blank"} template named '[typescript-axios](https://openapi-generator.tech/docs/generators/typescript-axios){:target="_blank"}'.

Using Yarn, we can create a command that will generate our API client fairly easily. Open up a command prompt or terminal in the directory of the project and execute the following commands. ***Note***: change `my-app` to the application name of your React Native project.

```bash
# CD into the project
cd my-app
# Add axios project dependencies
yarn add axios url
# Add client generator (as Dev dependency)
yarn add -D @openapitools/openapi-generator-cli
# Create api folder (for everything API related). It should be lowercase to avoid warnings
mkdir api
# Download Open API file to api folder
curl https://cwjg-contacts-api.azurewebsites.net/swagger/v1/swagger.json > ./api/openapi.json
# Add generator script to package.json
npx add-project-script -n "openapi" -v "openapi-generator-cli generate -i ./api/openapi.json -g typescript-axios -o ./api/generated"
# Generate the client (requires JDK installed)
yarn openapi
```

If your API changes and you need to update your API client, just execute the following command

```bash
yarn openapi
```

to generate a new client

## Getting started

### Create the API client

>For the sake of this blog post, I named my application ***Contacts*** with it using ***ContactsApi*** as the name of my API client. You can replace `Contacts` with `my-app` or whatever you called your application. This blog post also assumes we are working on a brand new React Native Application.

The first step is to expose the API client to our React Native application.

In the `./Contacts/api` folder, create a new file `index.ts` with the following contents

```javascript
import { ContactsApi } from './generated';

export default {
    Contacts: new ContactsApi()
};
```

Now that the API is exposed, let's use the API.  Navigate to the `App.tsx` file, in the project root folder, import the `Api`.  *Note*: if you are using an IDE, it could insert this `import` for you.

```jsx
import Api from './api'
```

Now we want to consume the API. Replace the HTML in the  `return()` block with this.

```jsx
<View style={styles.container}>
    <Button title="Hello" onPress={() => {
    var list = Api.Contacts.contactsGet();
    console.log("Hello");}} />
</View>
```

On the third line, you will see that we are calling `Api.Contacts.contactsGet();`. We are not doing anything with the `list` variable yet. We are just getting the API *connected*.  Now the call to the API will not work yet because we are still *wiring it up*.  If you want to see it working, you can execute the following command:

```bash
yarn web
```

in your terminal to start up the application.  Clicking on the 'Hello' button will log the word 'Hello' to the developer tools console.

### Configure security

Now we have to wire up the security.  To do that we first need to install the NPM Package for Microsoft Authentication Library (MSAL). **Note**: Make sure you are in the `Contact` directory in your terminal session.

```bash
yarn add msal
```

Once the package is done installing, create a folder in `Contacts` called `msal`. This folder will be used for the classes that interact with the Microsoft Identity library. You will need to create three files in the `msal` folder.

#### IRequestConfiguration.ts

This file contains the class the represents the request with scopes.

```typescript
export default interface IRequestConfiguration {
    scopes: string[];
    state?: string;
}
```

[Download](https://gist.github.com/jguadagno/56fa09b2e5498824795e3a41b2629866/raw/f5797bade7486ecd2fc5322c8a558d6606b562bc/IRequestConfiguration.ts){:target="_blank"}

#### MsalConfig.ts

This file contains the configuration for the library.  You will need to edit this class based on your Azure and authentication configuration. You'll need to at minimum change the `config.auth.clientId` to match that of the Azure client id.

```jsx
const MsalConfig = {
    config: {
        // Azure Credentials
        auth: {
            clientId: '', // Replace with your client id
            authority: "https://login.microsoftonline.com/common",
            redirectUri: "http://localhost:19006/Auth",
            navigateToLoginRequestUrl: false,
            validateAuthority: false
        },
        cache: {
            cacheLocation: "sessionStorage" // session storage is more secure, but prevents single-sign-on from working. other option is 'localStorage'
        } as const
    },
    // The default scopes are listed here since the scopes for individual pages may be different
    // Replace there with any default scopes you need for your application.
    defaultRequestConfiguration: {
        scopes: ["scope1", "scope2"]
    }
}
export default MsalConfig;
```

[Download](https://gist.github.com/jguadagno/56fa09b2e5498824795e3a41b2629866/raw/f5797bade7486ecd2fc5322c8a558d6606b562bc/MsalConfig.ts){:target="_blank"}

#### MsalHandler.ts

This file contains the interactions between your application and the Microsoft Identity library.

```typescript
import { UserAgentApplication, AuthResponse, AuthError } from 'msal';
import MsalConfig from './MsalConfig';
import IRequestConfiguration from "./IRequestConfiguration";

class UserInfo {
    accountAvailable: boolean;
    displayName: string;
    constructor() {
        this.displayName = "";
        this.accountAvailable = false;
    }
}

export default class MsalHandler {
    msalObj: UserAgentApplication;
    redirect: boolean;
    useStackLogging: boolean;

    // for handling a single instance of the handler, use getInstance() elsewhere
    static instance: MsalHandler;
    private static createInstance() {
        var a = new MsalHandler();
        return a;
    }

    public static getInstance() {
        if (!this.instance) {
            this.instance = this.createInstance();
        }
        return this.instance;
    }

    // default scopes from configuration
    private requestConfiguration: IRequestConfiguration = MsalConfig.defaultRequestConfiguration;

    // we want this private to prevent any external callers from directly instantiating, instead rely on getInstance()
    private constructor() {
        this.redirect = true;
        this.useStackLogging = false;
        const a = new UserAgentApplication(MsalConfig.config);

        a.handleRedirectCallback((error, response) => {
            if (response) {
                this.processLogin(response);
            }
            if (error) {
                console.error(error);
            }
        });
        this.msalObj = a;
    }

    public async login(redirect?: boolean, state?: string, scopes?: string[]) {
        if (state) {
            this.requestConfiguration.state = JSON.stringify({ appState: true, state });
        }
        if (redirect || this.redirect) {
            this.msalObj.loginRedirect(this.requestConfiguration);
        } else {
            try {
                var response = await this.msalObj.loginPopup(this.requestConfiguration);
                this.processLogin(response);
            } catch (e) {
                console.error(e);
            }
        }
    }

    public async acquireAccessToken(state?: string, redirect?: boolean, scopes?: string[]): Promise<String | null> {
        if (scopes) {
            this.requestConfiguration.scopes = scopes;
        }
        if (state) {
            this.requestConfiguration.state = JSON.stringify({ appState: true, state });
        }
        try {
            var token = await this.msalObj.acquireTokenSilent(this.requestConfiguration);
            return token.accessToken;
        } catch (e) {
            if (e instanceof AuthError) {
                console.error("acquireAccessToken: error: " + JSON.stringify(e));
                if (e.errorCode === "user_login_error" || e.errorCode === "consent_required" || e.errorCode === "interaction_required") { // todo: check for other error codes
                    this.login(redirect, state, this.requestConfiguration.scopes);
                }
            }
            console.error(e);
        }
        return null;
    }

    public getUserData(): UserInfo {
        var account = this.msalObj.getAccount();
        var u = new UserInfo();
        if (account) {
            u.accountAvailable = true;
            u.displayName = account.name;
        }
        return u;
    }

    public processLogin(response: AuthResponse | undefined) {
        if (!response) return;

        if (response.accountState) {
            try {
                var state = JSON.parse(response.accountState);
                if (state.appState) { // we had a redirect from another place in the app before the authentication request
                    window.location.pathname = state.state;
                }
            } catch {
                console.log("couldn't parse state - maybe not ours");
            }
        }
    }
}
```

[Download](https://gist.github.com/jguadagno/56fa09b2e5498824795e3a41b2629866/raw/f5797bade7486ecd2fc5322c8a558d6606b562bc/MsalHandler.ts){:target="_blank"}

Outside of the initial changes to `MsalConfig.ts`, you shouldn't have to change these files once you create them.

### Create the Azure Client Application

I've covered how to register/create an application in Azure before. If you haven't done this before, check out '[Working with Microsoft Identity - Registering an Application]({% link _posts/2020-08-29-working-with-microsoft-identity-registering-an-application.md %})'

Once you created the application, update `Contacts\msal\MsalConfig.ts` with the correct client id.

### Verify the Authentication is Working

To verify that we have the authentication configuration working we are going to build a screen that will use the `MsalHandler` to interact with the Microsoft Identity library and services. Create a folder called `screens`, the folder structure is totally optional.  I typically break out the folder structure of my applications based on functionality, so screens makes sense to me. We are going to create a file called `Auth.tsx`.  This screen will serve two purposes right now, the first is to log you into the application, the second is to show you what is in the token that Microsoft Identity library is using.

***NOTE*** You should not use most of this code in production.  Do not show your tokens or credentials in your application
{: .notice--danger}

#### Auth.tsx

Paste in the following contents into the newly created `auth.tsx`.

```jsx
import React from 'react';
import { Button, View, Text, FlatList, StyleSheet } from 'react-native';
import MsalHandler from '../msal/MsalHandler';

export class Claim {
    key: string;
    value: string;

    constructor(key: string, value: string) {
        this.key = key;
        this.value = value;
    }
}

export default class Auth extends React.Component {
    msalHandler: MsalHandler;
    accountAvailable: boolean;

    constructor(props: any) {
        super(props);
        this.msalHandler = MsalHandler.getInstance(); // note this returns the previously instantiated MsalHandler
        this.handleClick = this.handleClick.bind(this);
        this.accountAvailable = false;
    }

    state = {
        claims: Array<Claim>(),
    }

    componentDidMount() {
        var account = this.msalHandler.msalObj.getAccount();
        if (account) {
            this.accountAvailable = true;
        }
        if (this.accountAvailable) {
            this.parseToken(this.msalHandler.msalObj.getAccount().idToken);
        }
        else { }
    }

    parseToken(token: any) {
        var claimData = Object.keys(token).filter(y => y !== "decodedIdToken" && y !== "rawIdToken").map(x => {
            return new Claim(x, Array.isArray(token[x]) ? token[x].join(",") : token[x].toString());
        });
        this.setState({ claims: claimData });
    }

    render() {
        if (this.accountAvailable) {
            return (
                <View style={styles.container}>
                    <Text>User Claims</Text>
                    <FlatList 
                        data={this.state.claims}
                        renderItem={(claimData) => (
                            <View style={styles.row}>
                                <Text style={styles.column}>{claimData.item.key}</Text>
                                <Text style={styles.column}>{claimData.item.value}</Text>
                            </View>
                        )} />
                </View>
            )
        } else {
            return (
                <View style={styles.container}>
                    <Button onPress={this.handleClick} title="Login" />
                </View>
            )
        }
    }

    async handleClick(e: any) {
        e.preventDefault();
        console.log("clicked");
        await this.msalHandler.login();
    }
}

const styles = StyleSheet.create({
    container: {
        flex: 1,
        backgroundColor: 'white',
        justifyContent: 'center',
        flexDirection: 'row',
        flexWrap: 'wrap',
        alignItems: 'flex-start'
    },
    row: {
        display: 'flex',
        flexDirection: 'row',
        flexWrap: 'wrap',
        width: '100%'
    },
    column: {
        display: 'flex',
        flexDirection: 'column',
        flexBasis: '50%',
        flex: 1
    }
});
```

Now, I'm not going to explain every line of the file just highlight the parts that are important to the authentication.

Line 3, imports the `MsalHandler` so it is available to this screen.

Line 5, declares a `Claim` class which is used to display the claims.  This is not needed for authentication but helpful while you are troubleshooting.

***Note*** Do not include the `Claim` class in the production version of your application.
{: .notice--danger}

Line 21, we get an instance of the `MsalHandler`.

Now in the `componentDidMount()` function, lines 30-39, we attempt to get the account for the current user via a call to  `msalHandler.msalObj.getAccount()` on line 31. If account is not `undefined`, we set the local variable `accountAvailable` equal to `true`.

The `parseToken` function, lines 41-46, are used to split the token into a key-value pair for display.  Again, this is for debugging and testing purposes. **DO NOT** include this code in your production application.

The `render` method handles the display logic which differs if the user is logged in or not.

The `handleClick` function, lines 72-76, performs the login by executing the `msalHandler.login()` method.

#### App.tsx

Now let us update the application to call the authentication page. Replace the contents of `App.tsx` with the following:

```jsx
import React from 'react';
import { Button, StyleSheet, Text, View } from 'react-native';
import Api from './api'

import { NavigationContainer } from '@react-navigation/native';
import { createStackNavigator } from '@react-navigation/stack';
import Auth from './screens/Auth';
import MsalHandler from './msal/MsalHandler';

const msal = MsalHandler.getInstance();
var user = msal.getUserData();

function HomeScreen({navigation}) {
  return (
    <View style={styles.container}>
      <Text>Welcome new followers!</Text>
      <Button title="Hello" onPress={() => {console.log("Hello");}} />
      <Button title={user.accountAvailable ? "Claims for " + user.displayName : "Login"} onPress={() => navigation.navigate('Auth')} />
    </View>
  );
}

const Stack = createStackNavigator();

export default function App() {
  return (
    <NavigationContainer>
    <Stack.Navigator>
      <Stack.Screen name="Home" component={HomeScreen} />
      <Stack.Screen name="Auth" component={Auth} />
    </Stack.Navigator>
  </NavigationContainer>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: 'white',
    alignItems: 'center',
    justifyContent: 'center',
  },
});

```

Again, I'm not going to explain the whole file just the parts related to the authentication.

Line 7 and 8, we import the new Auth screen and the `MsalHandler` library.

Line 10, we create an instance of the `MsalHandler`.

Line 11, we attempt to get the user data from `getUserData` function of the `MsalHandler`. The call checks to see if there if the user has authenticated and has an access token already.

Line 18, determines whether to display the link to the authentication page or the user information.  If the user is already authenticated, the button will change to the users' name, in my case, the button will be titled *Claims for Joseph Guadagno*, if the user is not logged in or authenticated, the button will display *Login*.

#### Test the Authentication

Start the application.  Execute the following command from the console.

```bash
yarn web
```

If this is the first time you are running this application with this client id, or the first time running the application with the assigned client id with the current user, Azure Active Directory will prompt you to log in and accept the permissions for the application.  In our sample, we are asking to call the APIs on behalf of the signed-in user. If prompted,

* Click on the 'Login' button
* Click the next 'Login' button
* Login, accept permissions

If the login was successful, the login button should change to *Claims for ...* where the ... is your name.

If you click on the *Claims for ...* button, you will the claims that was sent back.

### Call the API

Now that we verified the API and application authentication works, we are going to need to update the API client to add the required headers for authentication and change the base URL.

#### index.js

Open up `Contacts/api/index.js` and replace the contents with the following:

```javascript
import Axios from 'axios';
import MsalHandler from '../msal/MsalHandler';
import { ContactsApi } from './generated';

const msalHandler = MsalHandler.getInstance();

const instance = Axios.create({baseURL: 'https://localhost:5001'});
instance.interceptors.request.use(
    async request => {
        var token = await msalHandler.acquireAccessToken(request.url);
        request.headers["Authorization"] = "Bearer " + token;
        return request;
    }
);

export default {
    Contacts: new ContactsApi(null, 'https://localhost:5001', instance)
};
```

As you can see, this is the first name where we are using the Axios library and this is the primary reason for using the Axios library and not the native React Native fetch function.  Axios provides us with the ability to *intercept* requests.  We want/need to intercept the request so we can add the required authentication header bearer token.

Line 5, we get an instance of the `MsalHandler`.

Line 7, we create an instance of the Axios library for the URL of `https://localhost:5001`.

Lines 8-14, we create an interceptor for any request to `https://localhost:5001`.  This interceptor will inject the token given from the Microsoft Identity library (line 10) call to `acquireAccessToken` and create a new *authorization* header with the bearer token, line 11;

Line 17, changes the initial creation of our API client to use the base URL of `localhost:5001` and the instance of Axios created on line 7.

***NOTE*** You'll want to change the URLs to your production URLs
{: .notice--info}

#### app.tsx

Now that the API client has been updated let's add a new button to the application so that we can make some APIs call to verify the authentication is working.

Open up the `App.tsx` file and add the following button.

```javascript
    <Button title="Number of Contacts" onPress={async () => {
        var contactList = await Api.Contacts.contactsGet();
        console.log("Number of contacts: " + contactList.data.length);

        var contact = await Api.Contacts.contactsIdGet(1);
        console.log("First Contact Name: '" + contact.data.fullName + "'");
      }} />
```

If the application is not already started, start it.  Then:

* Open up the developer tools of your browser
* Click the *Console* tabs
* Click on the number of Contacts

Now, if you had access to the API, you would have seen *Number of contacts: 5* and *First Contact Name: 'Joseph Guadagno'* in the developer tools console.

## Wrap Up

Wow, that was a lot.  As you can see, the initial setup is a little challenging but once it is done there is nothing you really need to do except for build your application.

## References

* [React Native](https://reactnative.dev)
* OpenAPI Tools [OpenAPI Generator](https://github.com/OpenAPITools/openapi-generator)
* [How to automate API code generation (OpenAPI/Swagger) and boost productivity](https://medium.com/tribalscale/how-to-automate-api-code-generation-openapi-swagger-and-boost-productivity-1176a0056d8a)
* [Using Axios with React to Make API Requests](https://upmostly.com/tutorials/using-axios-with-react-api-requests)
* [React Native Dev Tools](https://microsoftedge.microsoft.com/addons/detail/react-developer-tools/gpphkfbcpidddadnkolkpfckpihlkkil)
* JP Dandison's, aka [@AzureAndChill](https://www.twitter.com/AzureAndChill) [Axios Intercept](https://github.com/jpda/msaljs-axios-intercept) with Microsoft Identity Library for JavaScript [MSAL.js](https://github.com/AzureAD/microsoft-authentication-library-for-js)
* Video: [Introduction to React Native](https://youtu.be/IScDA7cKsSM)
* Video: [Building the API Client and Authentication](https://youtu.be/9Wot8p9bWf4)
* Completed code repository at [https://github.com/jguadagno/contacts-react-native-client](https://github.com/jguadagno/contacts-react-native-client)