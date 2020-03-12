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
class Weather {
    conditions(city) {
        return __awaiter(this, void 0, void 0, function* () {
            const query = `select * from weather.forecast where woeid in (select woeid from geo.places(1) where text="${city}, ak") and u='c'`;
            const response = yield this.performQuery(query);
            return response.data.query.results.channel.item.condition;
        });
    }
    performQuery(query) {
        return __awaiter(this, void 0, void 0, function* () {
            const endpoint = `https://query.yahooapis.com/v1/public/yql?q=${query}&format=json`;
            return yield axios.get(endpoint);
        });
    }
}
export default new Weather();
//# sourceMappingURL=weather-service.js.map