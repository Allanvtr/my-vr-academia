import styled from 'styled-components/native';
import Ionicons from 'react-native-vector-icons/Ionicons';
import { useAppNavigation } from '../../hooks/useAppNavigation';
import { TouchableOpacity } from 'react-native';

const Container = styled.View`
    height: 84px;
    width: 100%;
    background-color: ${({ theme }) => theme.colors.secondary};
    flex-direction: row;
    align-items: center;
    justify-content: space-between;
    padding-left: 30px;
    padding-right: 30px;
    
    position: absolute;
    bottom: 0;
`;

const IconSize = 40;
const IconColor = "white"

export default function BottomBar() {
    const navigation = useAppNavigation();

    return(
        <Container>
            <TouchableOpacity
                onPress={() => navigation.navigate('Home')}
            >
                <Ionicons
                    name="home-outline"
                    size={IconSize}
                    color={IconColor}
                />
            </TouchableOpacity>
            
            <TouchableOpacity
                onPress={() => navigation.navigate('Home')}
            >
                <Ionicons
                    name="time-outline"
                    size={IconSize}
                    color={IconColor}
                />
            </TouchableOpacity>
            <TouchableOpacity
                onPress={() => navigation.navigate('Home')}
            >
                <Ionicons
                    name="star-outline"
                    size={IconSize}
                    color={IconColor}
                />
            </TouchableOpacity>

            <TouchableOpacity
                onPress={() => navigation.navigate('Home')}
            >
                <Ionicons
                    name="settings-outline"
                    size={IconSize}
                    color={IconColor}
                />
            </TouchableOpacity>
        </Container>
    );
}