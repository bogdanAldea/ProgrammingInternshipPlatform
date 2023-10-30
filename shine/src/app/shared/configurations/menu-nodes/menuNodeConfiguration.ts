import { NodeData } from "../../components/navigations/node/types/nodeData";
import { MenuNodes } from "./nodes";

export class MenuNodeConfiguration {
    public static userRole: string  = 'Administrator';

    public static getMenu = (): NodeData[] => {
        switch (this.userRole) {
            case 'Administrator':
                return MenuNodes.ForAdministrator;
            default:
                throw new Error();
        }
    }

    public static getSettingsForSelectedInternship = (): NodeData[] => {
        return MenuNodes.ForSelectedInternship;
    }

    public static getSettingsForSelectedChapter = (): NodeData[] => {
        return MenuNodes.ForSelectedChapter;
    }
}
