var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
import axios from 'axios';
class DashboardService {
    constructor() {
        this.code = "";
        this.initialize();
    }
    player(query) {
        return __awaiter(this, void 0, void 0, function* () {
            const response = yield this.performQuery(query);
            return response.data;
        });
    }
    currentlyPlaying(query) {
        return __awaiter(this, void 0, void 0, function* () {
            const response = yield this.performQuery(query);
            return response.data;
        });
    }
    performQuery(query) {
        return __awaiter(this, void 0, void 0, function* () {
            const endpoint = `/api/player/auth/${this.code}/${query}`;
            return yield axios.get(endpoint);
        });
    }
    initialize() {
        return __awaiter(this, void 0, void 0, function* () {
        });
    }
}
export default new DashboardService();
//# sourceMappingURL=dashboard-service.js.map