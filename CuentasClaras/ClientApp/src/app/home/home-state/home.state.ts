import { Action, Selector, State, StateContext } from '@ngxs/store';
import { HomeStateModel } from './home-state';
import { SetTopBuyersAction, SetTopItemsAction, SetTopSuppliersAction } from './actions';

@State<HomeStateModel>({
  name: 'home'
})
export class HomeState {
  @Selector()
  public static topBuyers(state: HomeStateModel) {
    return state.topBuyers;
  }

  @Selector()
  public static topSuppliers(state: HomeStateModel) {
    return state.topSuppliers;
  }

  @Selector()
  public static topItems(state: HomeStateModel) {
    return state.topItems;
  }

  @Action(SetTopBuyersAction)
  public SetTopBuyers({patchState}: StateContext<HomeStateModel>, {payload}: SetTopBuyersAction) {
    patchState({topBuyers: payload});
  }

  @Action(SetTopSuppliersAction)
  public setTopSuppliers({patchState}: StateContext<HomeStateModel>, {payload}: SetTopSuppliersAction) {
    patchState({topSuppliers: payload});
  }

  @Action(SetTopItemsAction)
  public setTopItemsAction({patchState}: StateContext<HomeStateModel>, {payload}: SetTopItemsAction) {
    patchState({topItems: payload});
  }
}
