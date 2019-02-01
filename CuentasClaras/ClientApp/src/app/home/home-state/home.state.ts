import { State } from '@ngxs/store';
import { HomeStateModel } from './home-state';

@State<HomeStateModel>({
  name: 'home',
})
export class HomeState {
  // @Selector()
  // public static getActiveRoute(state: HomeStateModel) {
  //   return state.activeRoute;
  // }
  //
  // @Action(SetActiveRoute)
  // public setActiveRoute({patchState}: StateContext<HomeStateModel>, {payload}: SetActiveRoute) {
  //   patchState({activeRoute: payload});
  // }
}
