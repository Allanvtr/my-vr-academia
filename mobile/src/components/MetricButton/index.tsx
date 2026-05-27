import Ionicons from 'react-native-vector-icons/Ionicons';
import * as S from './styles';

type Props = {
  icon: string;
  metric: string;
  onPress: () => void;
};

export default function MetricButton({ icon, metric, onPress }: Props) {
    return(
        <S.Container
            onPress={onPress}
        >
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