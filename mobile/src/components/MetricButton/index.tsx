import Ionicons from 'react-native-vector-icons/Ionicons';
import * as S from './styles';

type Props = {
  icon: string;
  metric: string;
  selected: boolean;
  onPress: () => void;
};

export default function MetricButton({icon, metric, selected, onPress}: Props) {
  return (
    <S.Container
      selected={selected}
      onPress={onPress}
    >
      <Ionicons
        name={icon}
        size={41}
        color={selected ? 'white' : 'black'}
      />

      <S.ButtonText
        selected={selected}
        numberOfLines={1}
        adjustsFontSizeToFit={true}
      >
        {metric}
      </S.ButtonText>
    </S.Container>
  );
}