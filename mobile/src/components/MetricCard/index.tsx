import Ionicons from 'react-native-vector-icons/Ionicons';
import * as S from './styles'
import { formatTime } from '../../utils/formatTime'
import { metrics } from '../../constants/metrics';

type Props = {
    icon: string,
    metric: number,
}

export default function MetricCard({ icon, metric }: Props){
    const tempoIcon = metrics.find(
        item => item.metric === 'Tempo'
    )?.icon;
    
    return(
        <S.Container>
            <Ionicons
                name={icon}
                size={33}
                color="black"
            />
            <S.MetricValue 
                numberOfLines={1} 
                adjustsFontSizeToFit={true}
            >
                {icon === tempoIcon 
                    ? formatTime(metric)
                    : metric
                }
            </S.MetricValue>
        </S.Container>
    );
}