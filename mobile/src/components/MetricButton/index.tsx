import Ionicons from 'react-native-vector-icons/Ionicons';
import * as S from './styles';

type Props = {
  icon: string;
  metric: string;
};

export default function MetricButton({ icon, metric }: Props) {
    return(
        <S.Container>
            <Ionicons
                name={icon}
                size={41}
                color="black"
            />
            <S.ButtonText 
                numberOfLines={1} 
                adjustsFontSizeToFit={true}
            >
                {metric}
            </S.ButtonText>
        </S.Container>
    );
}