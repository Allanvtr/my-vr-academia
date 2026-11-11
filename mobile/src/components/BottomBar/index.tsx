import * as S from './styles';
import Ionicons from 'react-native-vector-icons/Ionicons';
import { useAppNavigation } from '../../hooks/useAppNavigation';
import { TouchableOpacity } from 'react-native';

export default function BottomBar() {
    const navigation = useAppNavigation();

    return(
        <S.Container>
            <TouchableOpacity
                onPress={() => navigation.navigate('Home')}
            >
                <Ionicons
                    name="home-outline"
                    size={S.IconSize}
                    color={S.IconColor}
                />
            </TouchableOpacity>
            
            <TouchableOpacity
                onPress={() => navigation.navigate('Home')}
            >
                <Ionicons
                    name="time-outline"
                    size={S.IconSize}
                    color={S.IconColor}
                />
            </TouchableOpacity>
            <TouchableOpacity
                onPress={() => navigation.navigate('Home')}
            >
                <Ionicons
                    name="star-outline"
                    size={S.IconSize}
                    color={S.IconColor}
                />
            </TouchableOpacity>

            <TouchableOpacity
                onPress={() => navigation.navigate('Home')}
            >
                <Ionicons
                    name="settings-outline"
                    size={S.IconSize}
                    color={S.IconColor}
                />
            </TouchableOpacity>
        </S.Container>
    );
}