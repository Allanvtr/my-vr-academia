import Ionicons from 'react-native-vector-icons/Ionicons';
import * as S from './styles'

type Props = {
    icon: string,
    metric: string,
}

export default function MetricCard({ icon, metric }: Props){
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
                {metric}
            </S.MetricValue>
        </S.Container>
    );
}