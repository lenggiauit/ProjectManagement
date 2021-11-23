import { Action, configureStore, ThunkAction } from '@reduxjs/toolkit';
import { setupListeners } from '@reduxjs/toolkit/query'
import { AccountService } from '../services/account';
import { TeamService } from '../services/team';
import userReducer from './userSlice';
export const store = configureStore({
    reducer: {
        currentUser: userReducer,
        // Add the generated reducer as a specific top-level slice 
        [AccountService.reducerPath]: AccountService.reducer,
        [TeamService.reducerPath]: TeamService.reducer,

    },
    // Adding the api middleware enables caching, invalidation, polling,
    // and other useful features of `rtk-query`.
    middleware: (getDefaultMiddleware) => {
        return getDefaultMiddleware({ serializableCheck: false })
            .concat(AccountService.middleware)
            .concat(TeamService.middleware);
    }
});

export type AppDispatch = typeof store.dispatch;
export type RootState = ReturnType<typeof store.getState>;
export type AppThunk<ReturnType = void> = ThunkAction<
    ReturnType,
    RootState,
    unknown,
    Action<string>
>;
setupListeners(store.dispatch)
