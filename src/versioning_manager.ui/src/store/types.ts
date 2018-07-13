import { Organization } from '@/models/Organization';

export interface RootState {
  loading: boolean;
  drawer: boolean;
}

export interface OrgState {
  orgList: Organization[];
}
