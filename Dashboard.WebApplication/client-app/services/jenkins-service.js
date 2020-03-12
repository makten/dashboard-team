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
class Jenkins {
    statistics(team, environment, pipeline) {
        return __awaiter(this, void 0, void 0, function* () {
            var teamx = encodeURI("Eile Mit Weile");
            var pipelinex = encodeURI("Stabilisatie-teststraat-ING");
            var environmentx = "ING";
            const query = `${environmentx}/view/${teamx}/view/${pipelinex}/view/pipeline`;
            const response = yield this.performQuery(query);
            return response.data.query.results.channel.item.condition;
        });
    }
    performQuery(query) {
        return __awaiter(this, void 0, void 0, function* () {
            const endpoint = `https://force-ci.topicusfinance.nl/view/${query}/api/json?pretty=true`;
            return yield axios.get(endpoint);
        });
    }
}
export default new Jenkins();
//# sourceMappingURL=jenkins-service.js.map